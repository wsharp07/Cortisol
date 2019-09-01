using System;

namespace Cortisol
{
    public interface IStressAction
    {
        IStressResult ActOn(Action action);
        IStressResult ActOnApi(Uri uri);
    }
}