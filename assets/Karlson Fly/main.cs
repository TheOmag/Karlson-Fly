using HarmonyLib;
using UnityEngine;

namespace main
{
    [HarmonyPatch(typeof(PlayerMovement))]
    [HarmonyPatch("Update", MethodType.Normal)]

    public class code
    {
        public static float speed = 50000f;
        public static float MultSpeed = 2f;

        private static bool OneOff = false;
        private static float currentSpeed = speed; 

        private static void Postfix(PlayerMovement __instance)
        {
            config.code.configSetValues();

            if (Input.GetKey(KeyCode.F))
            {
                groundFix.code.FlyingFixGround();
                __instance.rb.velocity = -__instance.ps.transform.forward * Time.deltaTime * currentSpeed;
                GameObject.Destroy(EZCameraShake.CameraShaker.Instance);
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    if (!OneOff)
                    {
                        currentSpeed *= MultSpeed;
                        OneOff = true;
                    }
                    else
                    {
                        currentSpeed = speed;
                        OneOff = false;
                    }
                }
                else
                {
                    currentSpeed = speed;
                }
            }
            if (Input.GetKeyUp(KeyCode.F)) stop();
        }
        private static void stop()
        {
            if (config.code.InstantStop)
            {
                PlayerMovement.Instance.rb.velocity = new Vector3(0f, 0f, 0f);
            }
        }
    }
}