using System;
using System.Collections.Generic;
using R3;
using UnityEngine;

namespace GravityPlatformer2D.Gameplay._Services.Implementations {
    public class InputService : IInputService, IDisposable {
        private readonly CompositeDisposable _disposables = new();
        private readonly ReactiveProperty<float> _moveVector = new();

        private Dictionary<Type, IInputProcessor> _inputProcessors = new();

        public ReadOnlyReactiveProperty<float> MoveVector => _moveVector;
        public event Action onJumpButtonPressed;

        public InputService(params IInputProcessor[] processors) {
            foreach (var processor in processors) {
                _inputProcessors.Add(processor.GetType(), processor);
            }
            
            foreach (var inputProcessor in _inputProcessors.Values) {
                inputProcessor.MoveVector
                              .Subscribe(MovementVectorChanged)
                              .AddTo(_disposables);
                
                inputProcessor.onJumpButtonPressed += JumpButtonPressed;
            }
        }

        public void Dispose() {
            foreach (var inputProcessor in _inputProcessors.Values) {
                if (inputProcessor != null) {
                    inputProcessor.onJumpButtonPressed -= JumpButtonPressed;
                }
            }
            _disposables?.Dispose();
        }
        
        public void Enable() {
            foreach (var inputProcessor in _inputProcessors.Values) {
                inputProcessor.Enable();
            }
        }
        
        public void Disable() {
            foreach (var inputProcessor in _inputProcessors.Values) {
                inputProcessor.Disable();
            }
        }

        public T TryGetInputProcessor<T>() where T : class, IInputProcessor {
            if (!_inputProcessors.TryGetValue(typeof(T), out var inputProcessor)) {
                return null;
            }
            
            return inputProcessor as T;
        }

        private void MovementVectorChanged(float moveVector) {
            var moveVectorSum = 0f;

            foreach (var inputProcessor in _inputProcessors.Values) {
                moveVectorSum += inputProcessor.MoveVector.CurrentValue;
            }
            
            _moveVector.Value = Mathf.Clamp(moveVectorSum, -1f, 1f);
        }

        private void JumpButtonPressed() {
            onJumpButtonPressed?.Invoke();
        }
    }
}
