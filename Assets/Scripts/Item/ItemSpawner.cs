using Scrap;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ItemManagement
{
    public class ItemSpawner : MonoBehaviour
    {
        /// <summary>Holds the Players current Data for Inventory Keeping and Cooldowns</summary>
        [SerializeField] private PlayerData playerData;

        /// <summary>Holds the Template for a Scrap</summary>
        [SerializeField] private GameObject templateScrap;

        /// <summary>Holds the Player for Location when spawning</summary>
        [SerializeField] private GameObject player;

        /// <summary>Holds the Button State for <c>placementCooldown</c></summary>
        private bool _isButtonActive;

        /// <summary>Holds the Button Input Action for Item Placement</summary>
        private InputAction _spawnAction;

        /// <summary>
        /// Inits the <c>_spawnAction</c> to the interact Action
        /// </summary>
        private void Awake()
        {
            _spawnAction = InputSystem.actions.FindAction("interact");
        }

        /// <summary>
        /// Checks for Button press on fixed interval in order to place an Item
        /// </summary>
        private void FixedUpdate()
        {
            if (!_spawnAction.IsPressed() || _isButtonActive) return;

            GameObject usageTemplate;
            switch (playerData.selectedItem)
            {
                case Item.Scrap:
                    if (playerData.items.scraps < 1) return; // TODO visual feedback
                    playerData.items.scraps -= 1;
                    usageTemplate = templateScrap;
                    break;
                case Item.Teleporter:
                    if (playerData.items.teleporters < 1) return; // TODO visual feedback
                    playerData.items.teleporters -= 1;
                    // usageTemplate = templateTeleporter
                    return;
                default:
                    return;
            }

            var targetSpawn = player.transform.position;
            Instantiate(usageTemplate, targetSpawn + new Vector3(0, 1, 0), Quaternion.identity)
                .GetComponent<ScrapController>()
                .enabled = true;
            _isButtonActive = true;
            Invoke(nameof(FreeButton), playerData.stats.placementCooldown);
        }

        /// <summary>Frees the Button from its earthly desires (switches <c>_isButtonActive</c> to false)</summary>
        private void FreeButton()
        {
            _isButtonActive = false;
        }
    }
}