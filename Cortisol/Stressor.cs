using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cortisol
{
    public sealed class Stressor : IStressCycle, IStressAction, IStressResult
    {
        private Uri _uri;
        private Action _action;
        private int _timesToRun;
        private readonly HttpClient _client = new HttpClient();

        public InduceType InduceType { get; private set; }
        public IStressResult ActOn(Action action)
        {
            _action = action;
            InduceType = InduceType.Action;
            return this;
        }

        public IStressResult ActOnApi(Uri uri)
        {
            _uri = uri;
            InduceType = InduceType.Api;
            return this;
        }

        public IStressAction RunTimes(int times)
        {
            _timesToRun = times;
            return this;
        }

        public async Task Induce()
        {
            switch (InduceType)
            {
                case InduceType.Action:
                {
                    InduceAction();
                    break;
                }
                case InduceType.Api:
                {
                    await InduceApi();
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void InduceAction()
        {
            for (var i = 0; i < _timesToRun; i++)
            {
                _action.Invoke();
            }
        }

        private async Task InduceApi()
        {
            for (var i = 0; i < _timesToRun; i++)
            {
                await _client.GetAsync(_uri);
            }
        }

    }
}