using UnityEngine;
using Zenject;

namespace Testovoe
{
    public class ButtonsControllerSystem : MonoBehaviour
    {
        private PickupItem _pickupItem;

        [Inject]
        public void Construct(PickupItem pickupItem)
        {
            _pickupItem = pickupItem;
        }
        
        public void DropItem()
        {
            _pickupItem.DropItem();
        }
    }
}