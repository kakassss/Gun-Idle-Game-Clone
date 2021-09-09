using System.Collections;
using System.Collections.Generic;
using UnityEngine;


	[ExecuteInEditMode]
	public class CameraAnchor : MonoBehaviour
	{
		public enum AnchorType
		{
			BottomLeft,
			BottomCenter,
			BottomRight,
			MiddleLeft,
			MiddleCenter,
			MiddleRight,
			TopLeft,
			TopCenter,
			TopRight,
		};
		public AnchorType anchorType;
		public Vector3 anchorOffset;

		IEnumerator updateAnchorRoutine; //Coroutine handle so we don't start it if it's already running

		// Use this for initialization
		void Start()
		{
			updateAnchorRoutine = UpdateAnchorAsync();
			StartCoroutine(updateAnchorRoutine);
		}

		/// <summary>
		/// Coroutine to update the anchor only once ViewportHandler.Instance is not null.
		/// </summary>
		IEnumerator UpdateAnchorAsync()
		{
			uint cameraWaitCycles = 0;
			while (CameraAspect.Instance == null)
			{
				++cameraWaitCycles;
				yield return new WaitForEndOfFrame();
			}
			if (cameraWaitCycles > 0)
			{
				print(string.Format("CameraAnchor found ViewportHandler instance after waiting {0} frame(s). You might want to check that ViewportHandler has an earlie execution order.", cameraWaitCycles));
			}
			UpdateAnchor();
			updateAnchorRoutine = null;
		}

		void UpdateAnchor()
		{
			switch (anchorType)
			{
				case AnchorType.BottomLeft:
					SetAnchor(CameraAspect.Instance.BottomLeft);
					break;
				case AnchorType.BottomCenter:
					SetAnchor(CameraAspect.Instance.BottomCenter);
					break;
				case AnchorType.BottomRight:
					SetAnchor(CameraAspect.Instance.BottomRight);
					break;
				case AnchorType.MiddleLeft:
					SetAnchor(CameraAspect.Instance.MiddleLeft);
					break;
				case AnchorType.MiddleCenter:
					SetAnchor(CameraAspect.Instance.MiddleCenter);
					break;
				case AnchorType.MiddleRight:
					SetAnchor(CameraAspect.Instance.MiddleRight);
					break;
				case AnchorType.TopLeft:
					SetAnchor(CameraAspect.Instance.TopLeft);
					break;
				case AnchorType.TopCenter:
					SetAnchor(CameraAspect.Instance.TopCenter);
					break;
				case AnchorType.TopRight:
					SetAnchor(CameraAspect.Instance.TopRight);
					break;
			}
		}

		void SetAnchor(Vector3 anchor)
		{
			Vector3 newPos = anchor + anchorOffset;
			if (!transform.position.Equals(newPos))
			{
				transform.position = newPos;
			}
		}

#if UNITY_EDITOR
		// Update is called once per frame
		void Update()
		{
			if (updateAnchorRoutine == null)
			{
				updateAnchorRoutine = UpdateAnchorAsync();
				StartCoroutine(updateAnchorRoutine);
			}
		}
#endif
	}

