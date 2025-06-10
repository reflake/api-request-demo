using System;
using Breeds.Data;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Breeds.Details
{
	public class Details
	{
		public string Name, Description;

		public Details(string name, string description)
		{
			Name = name;
			Description = description;
		}
	}
	
	public class Model : IDisposable
	{
		private const string ApiPath = "https://dogapi.dog/api/v2/breeds";
		
		private readonly string _id;
		private UnityWebRequest _currentRequest = null;

		public Model(string id)
		{
			_id = id;
		}

		public void Dispose()
		{
			TryCancelRequest();
		}
		
		public async UniTask<Details> GetDetailsAsync()
		{
			TryCancelRequest();
			
			_currentRequest = UnityWebRequest.Get($"{ApiPath}/{_id}");
			
			var response = await _currentRequest.SendWebRequest();
			var data = JsonUtility.FromJson<ResponseDetailsData>(response.downloadHandler.text).data;

			return new Details(
				data.attributes.name, 
				data.attributes.description);
		}

		private void TryCancelRequest()
		{
			if (_currentRequest != null && !_currentRequest.isDone)
			{
				_currentRequest.Abort();
			}
		}
	}
}