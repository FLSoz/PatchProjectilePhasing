using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using Harmony;
using System.Reflection;


namespace PatchProjectilePhasing
{
    public static class IngressPoint
    {
        /* [HarmonyPatch(typeof(Projectile))]
        [HarmonyPatch("OnPool")]
        public static class PatchProjectile
        {
            public static void Postfix(ref Projectile __instance)
            {
                if (__instance.rbody.collisionDetectionMode != CollisionDetectionMode.ContinuousDynamic)
                {
                    // Console.WriteLine("PAtching a projectile");
                    __instance.rbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                }
            }
        } */

        [HarmonyPatch(typeof(Projectile))]
        [HarmonyPatch("OnSpawn")]
        public static class CheckProjectile
        {
            private static FieldInfo m_IgnoreCollisionWithBarrel = typeof(Projectile).GetField("m_IgnoreCollisionWithBarrel", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            public static void Postfix(ref Projectile __instance)
            {
                if (__instance.rbody.collisionDetectionMode != CollisionDetectionMode.ContinuousDynamic)
                {
                    // Console.WriteLine("PAtching a projectile");
                    __instance.rbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                }
                // CheckProjectile.m_IgnoreCollisionWithBarrel.SetValue(__instance, true);
                // Console.WriteLine(__instance.rbody.collisionDetectionMode);
            }
        }

        public static void Main()
        {
            HarmonyInstance.Create("flsoz.ttmm.projectilephasingpatch.mod").PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
