namespace KBEngine
{
  	using UnityEngine; 
	using System; 
	using System.Collections; 
	using System.Collections.Generic;
	
    public class Skill 
    {
    	public string name;
    	public string descr;
    	public Int32 id;
    	public float canUseDistMin = 0f;
    	public float canUseDistMax = 3f;

        // ���һ��ʹ��ʱ�䣬 ��õ������Ǹ��ͻ���ʵ������cooldownϵͳ������demoֻ�Ǽ�չʾ����������ʵ�ֹ���
    	public System.DateTime lastUsedTime = System.DateTime.Now;

        public Skill()
		{
		}
		
		public bool validCast(KBEngine.Entity caster, SCObject target)
		{
            TimeSpan span = DateTime.Now - lastUsedTime;
            if (span.TotalMilliseconds < 300)
                return false;

            float dist = Vector3.Distance(target.getPosition(), caster.position);
			if(dist > canUseDistMax)
				return false;
			
			return true;
		}
		
		public void use(KBEngine.Entity caster, SCObject target)
		{
			caster.cellCall("useTargetSkill", id, ((SCEntityObject)target).targetID);
            lastUsedTime = System.DateTime.Now;
        }
    }
} 
