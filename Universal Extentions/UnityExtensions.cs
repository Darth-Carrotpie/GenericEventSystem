﻿//It is common to create a class to contain all of your
//extension methods. This class must be static.
//Split the extensions into scripts depending on what they extend for better management.
namespace GenericEventSystem {
    public static class TempUnityExtensions {
        //Even though they are used like normal methods, extension
        //methods must be declared static. Notice that the first
        //parameter has the 'this' keyword followed by a Transform
        //variable. This variable denotes which class the extension
        //method becomes a part of.

        //Example:
        /*public static void ResetTransformation(this Transform trans) {
            trans.position = Vector3.zero;
            trans.localRotation = Quaternion.identity;
            trans.localScale = new Vector3(1, 1, 1);
        }*/

    }
}