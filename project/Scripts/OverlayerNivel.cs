using UnityEngine;
using System.Collections;

public class OverlayerNivel : MonoBehaviour 
{
	

	public GUITexture backgroundImage;
	public KinectWrapper.NuiSkeletonPositionIndex TrackedJoint = KinectWrapper.NuiSkeletonPositionIndex.HandRight;
	public GameObject OverlayObject;
	public float smoothFactor = 5f;

	public GUIText debugText;

	private float distanceToCamera = 10f;

	bool bandera=true;

	void Start()
	{
		if(OverlayObject)
		{
			distanceToCamera = (OverlayObject.transform.position - Camera.main.transform.position).magnitude;
		}
	}

	void Update() 
	{
		KinectManager manager = KinectManager.Instance;

		if(manager && manager.IsInitialized())
		{
			//backgroundImage.renderer.material.mainTexture = manager.GetUsersClrTex();
			if(backgroundImage && (backgroundImage.texture == null))
			{
				backgroundImage.texture = manager.GetUsersClrTex();
			}

			//			Vector3 vRight = BottomRight - BottomLeft;
			//			Vector3 vUp = TopLeft - BottomLeft;

			int iJointIndex = (int)TrackedJoint;

			if(manager.IsUserDetected())
			{
				uint userId = manager.GetPlayer1ID();

				if(manager.IsJointTracked(userId, iJointIndex))
				{
					Vector3 posJoint = manager.GetRawSkeletonJointPos(userId, iJointIndex);

					if(posJoint != Vector3.zero)
					{
						// 3d position to depth
						Vector2 posDepth = manager.GetDepthMapPosForJointPos(posJoint);

						// depth pos to color pos
						Vector2 posColor = manager.GetColorMapPosForDepthPos(posDepth);

						float scaleX = (float)posColor.x / KinectWrapper.Constants.ColorImageWidth;
						float scaleY = 1.0f - (float)posColor.y / KinectWrapper.Constants.ColorImageHeight;

						//						Vector3 localPos = new Vector3(scaleX * 10f - 5f, 0f, scaleY * 10f - 5f); // 5f is 1/2 of 10f - size of the plane
						//						Vector3 vPosOverlay = backgroundImage.transform.TransformPoint(localPos);
						//Vector3 vPosOverlay = BottomLeft + ((vRight * scaleX) + (vUp * scaleY));

						if(debugText)
						{
							debugText.GetComponent<GUIText>().text = "Tracked user ID: " + userId;  // new Vector2(scaleX, scaleY).ToString();
						}

						if(OverlayObject)
						{
							Vector3 vPosOverlay = Camera.main.ViewportToWorldPoint(new Vector3(scaleX, scaleY, distanceToCamera));
							OverlayObject.transform.position = Vector3.Lerp(OverlayObject.transform.position, vPosOverlay, smoothFactor * Time.deltaTime);
						}

						Debug.Log (" nivel X "+scaleX+" Y:"+scaleY);
					

										if (scaleX >= 0.72) {
											if (scaleY >= 0.54 && scaleY <= 0.6791) {
											
												Debug.Log ("Intermedio");
									DatoInicio.dato.setNivel ("Intermedio");
												Application.LoadLevel ("modoJuego 1");
												bandera = false;
											
											}

										}

										if (scaleX <= 0.255) {
											if (scaleY >= 0.54 && scaleY <= 0.666) {
												Debug.Log ("Facil");
									DatoInicio.dato.setNivel ("Facil");
											    bandera = false;
												Application.LoadLevel ("modoJuego 1");
											}

										}

										if (scaleX <= 0.22) {
											if (scaleY <= 0.18) {
												Debug.Log ("Regresar");
												bandera = false;
												Application.LoadLevel ("KinectOverlayDemo");
											}
										}
										

										if (scaleX >= 0.76625) {
											if (scaleY <= 0.18) {
												Debug.Log ("salir");
												
												Application.Quit ();
											}
										}
						

					}
				}

			}

		}
	}
}
