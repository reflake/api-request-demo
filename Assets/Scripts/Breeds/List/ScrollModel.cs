using System;
using System.Linq;
using System.Threading.Tasks;
using Breeds.Data;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Breeds.List
{
	public class Breed
	{
		public int Index;
		public string Id;
		public string Name;

		public Breed(int index, string id, string name)
		{
			Index = index;
			Id = id;
			Name = name;
		}
	}
	
	public class ScrollModel : IDisposable
	{
		private const string ApiPath = "https://dogapi.dog/api/v2/breeds";
		
		private UnityWebRequest _currentRequest = null;
		
		public async UniTask<Breed[]> LoadEntries()
		{
			if (_currentRequest != null && !_currentRequest.isDone)
				throw new TaskCanceledException();
			
			_currentRequest = UnityWebRequest.Get(ApiPath);
			var response = await _currentRequest.SendWebRequest();
			var data = JsonUtility.FromJson<ResponseData>(response.downloadHandler.text);

			Breed[] output = new Breed[data.data.Length];

			for (int i = 0; i < data.data.Length; i++)
			{
				var itemData = data.data[i];
				
				output[i] = new Breed(i, itemData.id, itemData.attributes.name);
			}
			
			return output;
		}
		
		public void Dispose()
		{
			TryCancelRequest();
		}
		
		public void TryCancelRequest()
		{
			if (_currentRequest != null && !_currentRequest.isDone)
			{
				_currentRequest.Abort();
			}
		}
	}
}