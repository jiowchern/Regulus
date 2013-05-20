

namespace Regulus.Project.TurnBasedRPG.Common
{


    using Regulus.Project.TurnBasedRPG.Serializable;
    using Samebest.Remoting;    

    public interface IVerify
    {
        Value<bool> CreateAccount(string name, string password);
        Value<bool> Login(string name, string password);
        void Quit();
        event System.Action RepeatLogin;
    };

    public interface IParking
    {
        Value<bool> CheckActorName(string name);
        Value<bool> CreateActor(ActorInfomation cai);
        Value<ActorInfomation[]> DestroyActor(string name);
        Value<ActorInfomation[]> QueryActors();
        void Back();
        void Select(string name);
    }

    public interface IPlayer
    {
        void Logout();
        void ExitWorld();
        Value<int> SetData(int i);        
    }
}