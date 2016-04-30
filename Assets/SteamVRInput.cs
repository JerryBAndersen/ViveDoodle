using UnityEngine;
using System.Collections;

class SteamVRInput : MonoBehaviour {
    SteamVR_Controller.Device cfarl = null, cfarr = null;
    GameObject repleft, repright;
    public Transform left, right;
    public GameObject prefableft, prefabright;
    Rigidbody rigidleft, rigidright;

    void Start() {
        repleft = Instantiate(prefableft);
        repright = Instantiate(prefabright);
        repleft.name = "repleft";
        repright.name = "repright";
    }

    void Update() {
        if (cfarl == null || cfarr == null) {
            // get the controllers by farthest left/right
            int farl = 0;
            int farr = 0;

            farl = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost);
            farr = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);

            if (farl < 0 || farr < 0) return;

            cfarl = SteamVR_Controller.Input(farl);
            cfarr = SteamVR_Controller.Input(farr);

            // apply transform to exposed objects/transforms
            repleft.transform.localPosition = cfarl.transform.pos;
            repright.transform.localPosition = cfarr.transform.pos;
            repleft.transform.localRotation = cfarl.transform.rot;
            repright.transform.localRotation = cfarr.transform.rot;
        }        

    }
}
