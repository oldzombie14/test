using UnityEngine;
using System.Collections;

public class UEnter : MonoBehaviour {
	private void LateUpdate(){
		GameObject tempClick = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
		if(tempClick!=null&&tempClick.transform.IsChildOf(this.transform)){
			if(Input.GetMouseButtonDown(0)){
				RoundUi tempRoundUiC=tempClick.GetComponentInParent<RoundUi>();
				if(tempRoundUiC!=null){
					if(tempRoundUiC.CheckFrontTra(tempClick.transform)){
						tempRoundUiC.SetAutoStopTime ();
						Debug.Log("click");
					}
				}
			}
		}
	}
}
