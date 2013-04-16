using System.Collections;

namespace Svelto.Tasks
{
	public class SingleTask: IEnumerator
	{
		public object Current 		{ get { return _enumerator.Current; } }
				 
		public SingleTask(IEnumerator enumerator)
		{
			SerialTasks task = new SerialTasks();
			
			task.Add(enumerator);
			
			_enumerator = task.GetEnumerator();
		}
		
		public SingleTask(IEnumerator enumerator, System.Action OnComplete)
		{
			SerialTasks task = new SerialTasks();
			
			task.Add(enumerator);
			
			task.onComplete += OnComplete;
			
			_enumerator = task.GetEnumerator();
		}
		
		public bool MoveNext()
		{
			return _enumerator.MoveNext();
		}
		public void Reset()
		{
			_enumerator.Reset();
		}
		
		private IEnumerator 		_enumerator;
	}
}

