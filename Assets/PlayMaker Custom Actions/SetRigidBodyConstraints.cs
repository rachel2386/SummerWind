// (c) Copyright HutongGames, LLC 2010-2012. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Physics)]
	[Tooltip("Sets the constraints of a rigidBody")]
	public class SetRigidBodyConstraints : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(Rigidbody))]
		public FsmOwnerDefault gameObject;
		
		public FsmBool freezePositionX;
		
		public FsmBool freezePositionY;
		
		public FsmBool freezePositionZ;
		
		public FsmBool freezeRotationX;
		
		public FsmBool freezeRotationY;
		
		public FsmBool freezeRotationZ;

		public override void Reset()
		{
			gameObject = null;
			freezePositionX = false;
			freezePositionY = false;
			freezePositionZ = false;
			
			freezeRotationX = false;
			freezeRotationY = false;
			freezeRotationZ = false;
				
		}

		public override void OnEnter()
		{
			DoSetConstraints();
			
			
			Finish();		
		}

		void DoSetConstraints()
		{
			GameObject go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				LogError("gameObject is null");
				return;
			}
			
			
			if (go.GetComponent<Rigidbody>() == null)
			{
				LogError("RigidBody Component required");
				return;
			}
			
			go.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			if (freezePositionX.Value)
			{
				go.GetComponent<Rigidbody>().constraints = go.GetComponent<Rigidbody>().constraints | RigidbodyConstraints.FreezePositionX ;
			}
			if (freezePositionY.Value)
			{
				go.GetComponent<Rigidbody>().constraints = go.GetComponent<Rigidbody>().constraints | RigidbodyConstraints.FreezePositionY ;
			}
			if (freezePositionZ.Value)
			{
				go.GetComponent<Rigidbody>().constraints = go.GetComponent<Rigidbody>().constraints | RigidbodyConstraints.FreezePositionZ ;
			}
			
			if (freezeRotationX.Value)
			{
				go.GetComponent<Rigidbody>().constraints = go.GetComponent<Rigidbody>().constraints | RigidbodyConstraints.FreezeRotationX ;
			}
			if (freezeRotationY.Value)
			{
				go.GetComponent<Rigidbody>().constraints = go.GetComponent<Rigidbody>().constraints | RigidbodyConstraints.FreezeRotationY ;
			}
			if (freezeRotationZ.Value)
			{
				go.GetComponent<Rigidbody>().constraints = go.GetComponent<Rigidbody>().constraints | RigidbodyConstraints.FreezeRotationZ ;
			}
		}
	}
}