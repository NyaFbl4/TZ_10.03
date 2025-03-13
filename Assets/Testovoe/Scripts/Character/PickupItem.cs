using UnityEngine;
using Zenject;

namespace Testovoe
{
    public class PickupItem : MonoBehaviour
    {
        [SerializeField] private Transform _handPosition; 

        private float _throwForce;
        private float _maxPickupDistance;
        
        private GameObject _item;

        [Inject]
        public void Construct(CharacterConfig config)
        {
            _throwForce = config.ThrowForce;
            _maxPickupDistance = config.MaxPickupDistance;
        }
        
        public void TakeItem(GameObject item)
        {
            if (_item == null)
            {
                float distanceToItem =
                    Vector3.Distance(transform.position, item.transform.position);

                if (distanceToItem <= _maxPickupDistance)
                {
                    _item = item;
                    _item.transform.position = _handPosition.position;
                    _item.transform.parent = _handPosition;
                    _item.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
        
        public void DropItem()
        {
            if (_item != null)
            {
                _item.transform.parent = null;
                Rigidbody rb = _item.GetComponent<Rigidbody>();
                rb.isKinematic = false;
                rb.AddForce(Camera.main.transform.forward * _throwForce, ForceMode.Impulse);
                _item = null;
            }
        }
    }
}