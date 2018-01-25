#pragma strict




    var pickObj: Transform = null;
    private var hit: RaycastHit;
    private var dist: float;
    private var newPos: Vector3;
    var distance : float = 5;


    function Update(){

        if (Input.GetMouseButton(0)){
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!pickObj){
                if (Physics.Raycast(ray, hit) && hit.transform.tag == "Pick" && Vector3.Distance(Camera.main.transform.position, hit.transform.position) < distance){
                    if (hit.rigidbody) hit.rigidbody.velocity = Vector3.zero;
                    pickObj = hit.transform;
                   
                    dist = Vector3.Distance(pickObj.position, Camera.main.transform.position);
                }
            }
            else {
                newPos = ray.GetPoint(dist);
                hit.rigidbody.MovePosition(newPos);  
            }    
        }
        else {
            pickObj = null;
        }
    }
