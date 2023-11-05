using System;
using UnityEngine;

namespace Assets.Visitor
{
    public abstract class Enemy: MonoBehaviour
    {
        public bool IsDied { get; private set; }

        public event Action<Enemy> Died;
        //Какая то общая логика врага: передвижение, жизни и тп.

        public void MoveTo(Vector3 position) => transform.position = position;

        public void Kill()
        {
            IsDied = true;
            Died?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
