var camera1 : Camera;
var camera2 : Camera;
 
function Start () {
 
        camera1.GetComponent.<Camera>().active = true;
        camera2.GetComponent.<Camera>().active = false;
}


 
function Update () {
 
        if(Input.GetKeyDown("q")) {
                camera1.GetComponent.<Camera>().active = false;
                camera2.GetComponent.<Camera>().active = true;
        }
 
        if(Input.GetKeyDown("r")) {
                camera2.GetComponent.<Camera>().active = false;
                camera1.GetComponent.<Camera>().active = true;
        }
}