using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoundUi : MonoBehaviour {
	private Transform centerTra;
	private Transform elementTra;
	public float radius=150f;
	public float heightMultiple=2f;
	public float speed=100f;
	public float amountAngle{ get; private set;}
	private Transform targetTra;
	private float beforeRadius;
	private float beforeHeightMultiple;
	private int unityVersion;
	public bool isAuto=true;
	public float autoSpeed=20f;
	public float intervalTime=3f;
	private float beforeAutoTime;
	public float autoStopTime=3f;
	private float beforeStopTime;
	private void Awake(){
		centerTra = this.transform.Find ("Center");
		elementTra = this.transform.Find ("Element");
		amountAngle = 0f;
		targetTra = null;
		beforeRadius = radius;
		beforeHeightMultiple = heightMultiple;
		unityVersion = int.Parse (Application.unityVersion.Split ('.') [0]);
		beforeAutoTime = 0f;
		beforeStopTime = 0f;
	}
	private void Start(){
		Create ();
		StartCoroutine (StartIEnumerator());
	}
	private IEnumerator StartIEnumerator(){
		foreach(Transform loopTra in elementTra){//刷新Ui初始化
			loopTra.GetComponent<Canvas>().enabled=false;
		}
		yield return new WaitForEndOfFrame ();
		foreach(Transform loopTra in elementTra){//刷新Ui初始化
			loopTra.GetComponent<Canvas>().enabled=true;
		}
		SetPos ();
		elementTra.GetComponent<UnityEngine.UI.GridLayoutGroup> ().enabled = false;//禁用格式排列
		yield return new WaitForEndOfFrame ();
		foreach(Transform loopTra in elementTra){//刷新Ui初始化
			loopTra.GetComponent<RectTransform>().sizeDelta+=Vector2.one;
		}
		yield return new WaitForSeconds (0.1f);
		foreach(Transform loopTra in elementTra){//刷新Ui初始化
			loopTra.GetComponent<RectTransform>().sizeDelta-=Vector2.one;
		}
		this.transform.Find("Front").GetComponent<Canvas>().sortingOrder=GetMaxSortOrder();
	}
	private void Update(){
		//检测半径变化
		if(beforeRadius!=radius){
			beforeRadius=radius;
			Create();
			this.transform.Find("Front").GetComponent<Canvas>().sortingOrder=GetMaxSortOrder();
			return;
		}
		//检测高度变化
		if(beforeHeightMultiple!=heightMultiple){
			beforeHeightMultiple=heightMultiple;
			Create();
			return;
		}
		//检测元素变化
		if(centerTra.childCount!=elementTra.childCount){
			Create();
		}
		if(isAuto&&Time.time>=beforeStopTime){
			if(amountAngle==0f){
				if(Time.time>=beforeAutoTime+intervalTime){
					beforeAutoTime=Time.time;
					float tempAngle = 360f/elementTra.childCount;
					amountAngle+=tempAngle;
					if(unityVersion<=5){//用于旧版本点击异常
						foreach(Transform loopTra in elementTra){//旋转时显示优先
							loopTra.GetComponent<Canvas>().overrideSorting=true;
						}
					}
				}
			}
		}
		float tempSpeed=speed;
		if(isAuto&&Time.time>=beforeStopTime){
			tempSpeed=autoSpeed;
		}
		//正在旋转
		if(amountAngle!=0f){
			float tempAngle = 360f/elementTra.childCount;//间隔角度
			if(amountAngle>=tempAngle+10f){//取余操作，确保总旋转在一个间隔之内
				amountAngle-=tempAngle;
			}
			else if(amountAngle<=-tempAngle-10f){//同上
				amountAngle+=tempAngle;
			}
			float tempOffset=0f;
			if(amountAngle>=2f){//正向旋转
				tempOffset=Time.deltaTime*tempSpeed;
			}
			else if(amountAngle<=-2f){//负向旋转
				tempOffset=-Time.deltaTime*tempSpeed;
			}
			else{//旋转完成
				centerTra.Rotate(Vector3.up*amountAngle);
				amountAngle=0f;
				if(unityVersion<=5){//用于旧版本点击异常
					foreach(Transform loopTra in elementTra){//旋转完点击优先
						loopTra.GetComponent<Canvas>().overrideSorting=false;
					}
				}
				goto ifA;//跳到ifA
			}
			centerTra.Rotate(Vector3.up*tempOffset);//执行旋转
			amountAngle-=tempOffset;
			SetPos();//同步元素位置
			if(targetTra!=null){//判断目标元素是否在最前方，是则停止继续旋转
				if(Mathf.Abs(targetTra.localPosition.x)<=10f&&targetTra.localPosition.z<=-10f){
					amountAngle=0f;
					targetTra=null;
					if(unityVersion<=5){//用于旧版本点击异常
						foreach(Transform loopTra in elementTra){//旋转完点击优先
							loopTra.GetComponent<Canvas>().overrideSorting=false;
						}
					}
				}
			}
			ifA:;
		}
		if(targetTra!=null){//未达到目标元素，则继续旋转
			if(targetTra.localPosition.x<=-10f){
				Left();
			}
			else if(targetTra.localPosition.x>=10f){
				Right();
			}
			else if(targetTra.localPosition.z>=10f){
				Right();
			}
			else{
				targetTra=null;
				if(unityVersion<=5){//用于旧版本点击异常
					foreach(Transform loopTra in elementTra){//旋转完点击优先
						loopTra.GetComponent<Canvas>().overrideSorting=false;
					}
				}
			}
		}
	}
	private void LateUpdate(){
		GameObject tempClick = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
		if(tempClick!=null&&tempClick.transform.IsChildOf(this.transform)){
			if(Input.GetMouseButtonDown(0)){
				if(tempClick.name=="LeftButton"){
					SetAutoStopTime();
					Left();
				}
				else if(tempClick.name=="RightButton"){
					SetAutoStopTime();
					Right();
				}
				else{
					if(tempClick.transform.parent.name=="Element"){
						if(tempClick.transform!=GetFrontTra()){
							SetTargetTra(tempClick.transform);
						}
					}
				}
			}
		}
	}
	public void Left(){
		float tempAngle = 360f/elementTra.childCount;
		amountAngle -= tempAngle;
		if(unityVersion<=5){//用于旧版本点击异常
			foreach(Transform loopTra in elementTra){//旋转时显示优先
				loopTra.GetComponent<Canvas>().overrideSorting=true;
			}
		}
	}
	public void Right(){
		float tempAngle = 360f/elementTra.childCount;
		amountAngle += tempAngle;
		if(unityVersion<=5){//用于旧版本点击异常
			foreach(Transform loopTra in elementTra){//旋转时显示优先
				loopTra.GetComponent<Canvas>().overrideSorting=true;
			}
		}
	}
	public void Create(){
		Transform tempFrontTra = GetFrontTra ();
		Vector3 tempBeforeCenterEul = centerTra.localEulerAngles;
		centerTra.localEulerAngles = Vector3.zero;
		float tempAngle = 360f/elementTra.childCount;
		while(centerTra.childCount>0){
			DestroyImmediate(centerTra.GetChild(0).gameObject);
		}
		foreach(Transform loopTra in elementTra){
			GameObject tempGobj = new GameObject ();
			tempGobj.transform.SetParent (centerTra,true);
			tempGobj.AddComponent<RectTransform>();
			tempGobj.transform.position=centerTra.position-new Vector3(0f,0f,radius);
			tempGobj.transform.localScale=Vector3.one;
			centerTra.Rotate(Vector3.up*tempAngle);
			if(loopTra.GetComponent<Canvas>()==null){
				loopTra.gameObject.AddComponent<Canvas>();
			}
			loopTra.GetComponent<Canvas>().overrideSorting=true;
			if(loopTra.GetComponent<UnityEngine.UI.GraphicRaycaster>()==null){
				loopTra.gameObject.AddComponent<UnityEngine.UI.GraphicRaycaster>();
			}
		}
		centerTra.localEulerAngles = tempBeforeCenterEul;
		SetTargetTra (tempFrontTra);
		SetPos ();
	}
	private void SetPos(){
		foreach(Transform loopElementChildTra in elementTra){
			int tempIndex=loopElementChildTra.GetSiblingIndex();
			loopElementChildTra.position=centerTra.GetChild(tempIndex).position;
			loopElementChildTra.localPosition+=Vector3.up*loopElementChildTra.localPosition.z/10f*heightMultiple;
			loopElementChildTra.GetComponent<Canvas>().sortingOrder=-(int)loopElementChildTra.localPosition.z+(int)radius+10;
		}
	}
	private Transform GetFrontTra(){
		Transform returnTra = null;
		float tempMaxValue = -1f;
		foreach(Transform loopTra in elementTra){
			float tempValue=-loopTra.localPosition.z;
			if(returnTra==null||tempValue>=tempMaxValue){
				tempMaxValue=tempValue;
				returnTra=loopTra;
			}
		}
		return returnTra;
	}
	public bool CheckFrontTra(Transform theTra){
		bool returnBool = false;
		if(amountAngle==0f&&theTra==GetFrontTra()){
			returnBool=true;
		}
		return returnBool;
	}
	public void SetTargetTra(Transform theTra){
		targetTra=theTra;
		SetAutoStopTime ();
	}
	public int GetMaxSortOrder(){
		return (int)radius*2+20;
	}
	public void SetAutoStopTime(float theAutoStopTime=-1f){
		float tempAutoStopTime=autoStopTime;
		if(theAutoStopTime!=-1f){
			tempAutoStopTime=theAutoStopTime;
		}
		beforeStopTime = Time.time + tempAutoStopTime;
	}
}
