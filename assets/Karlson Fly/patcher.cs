using HarmonyLib;
using BepInEx;
using System.Reflection;

namespace patcher
{

    [BepInPlugin("org.Crafterbot.karlson.karlsonFly", "karlson Fly", "5.4.17.0")]
    public class patcher : BaseUnityPlugin
    {
        public void Awake()
        {
            var harmony = new Harmony("com.Crafterbot.karlson.karlsonFly");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            config.code.run();
        }
    }
}