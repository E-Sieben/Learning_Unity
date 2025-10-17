using UnityEngine;

namespace Scrap
{
    /// <summary>
    ///     Controls all Movement done by a Scrap
    /// </summary>
    internal static class MovementService
    {
        /// <summary>
        ///     Moves a Rigidbody to a Target Location
        /// </summary>
        /// <param name="controllableRigidbody">The Rigidbody to move</param>
        /// <param name="sourceLocation">The Vec3 of the current Location</param>
        /// <param name="targetLocation">The Vec3 of the target Location</param>
        /// <param name="magnetStrength">The MagnetStrength, also usable as Movement Speed</param>
        public static void TargetALocation(
            Rigidbody controllableRigidbody,
            Vector3 sourceLocation,
            Vector3 targetLocation,
            float magnetStrength
        )
        {
            var addVelocityTo = targetLocation - sourceLocation;
            controllableRigidbody.linearVelocity += addVelocityTo * magnetStrength;
            if (targetLocation.y > controllableRigidbody.position.y)
                controllableRigidbody.linearVelocity += new Vector3(0, magnetStrength, 0);
        }
    }
}