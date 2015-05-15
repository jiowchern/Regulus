﻿using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace VGame.Project.FishHunter.Storage
{
    public class Server : Regulus.Utility.ICore, IStorage 
    {

        Regulus.Utility.Updater _Updater;
        VGame.Project.FishHunter.Storage.Center _Center;
        Regulus.Utility.ICore _Core { get { return _Center; } }
        Regulus.NoSQL.Database _Database;
        private string _Ip;
        private string _Name;
        private string _DefaultAdministratorName;

        public Server()
        {
            _DefaultAdministratorName = "vgameadmini";
            _Ip = "mongodb://127.0.0.1:27017";
            _Name = "VGame";
            _Updater = new Regulus.Utility.Updater();
            _Database = new Regulus.NoSQL.Database(_Ip);
            _Center = new Center(this);
        }
        void Regulus.Utility.ICore.ObtainController(Regulus.Remoting.ISoulBinder binder)
        {
            _Core.ObtainController(binder);
        }

        bool Regulus.Utility.IUpdatable.Update()
        {
            _Updater.Update();
            return true;
        }

        void Regulus.Framework.ILaunched.Launch()
        {
            _RegisterCustomSerializer();    
            
            _Updater.Add(_Center);
            _Database.Launch(_Name);



            

            _HandleAdministrator();


            var account = _Find("vgameadmini");
            _HandleGuest();


            
        }

        private void _RegisterCustomSerializer()
        {
            
            ///MongoDB.Bson.Serialization.BsonSerializer.RegisterGenericSerializerDefinition(typeof(Regulus.CustomType.Flag<>), typeof(FlagSerializer<>));
        }

        

        private async void _HandleAdministrator()
        {
            var accounts = await _Database.Find<Data.Account>(a => a.Name == _DefaultAdministratorName);

            if (accounts.Count == 0)
            {
                var account = new Data.Account()
                {
                    Id = Guid.NewGuid(),
                    Name = _DefaultAdministratorName,
                    Password = "vgame",
                    Competnces = Data.Account.AllCompetnce()
                };

                await _Database.Add(account);
            }
        }

        async private void _HandleGuest()
        {
            var accounts = await _Database.Find<Data.Account>(a => a.Name == "Guest");

            if (accounts.Count == 0)
            {
                var account = new Data.Account()
                {
                    Id = Guid.NewGuid(),
                    Name = "Guest",
                    Password = "vgame",
                    Competnces = new Regulus.CustomType.Flag<Data.Account.COMPETENCE>(Data.Account.COMPETENCE.FORMULA_QUERYER)
                };
                await _Database.Add(account);
            }
        }

        void Regulus.Framework.ILaunched.Shutdown()
        {
            _Database.Shutdown();
            _Updater.Shutdown();
        }

        Regulus.Remoting.Value<Data.Account> IAccountFinder.FindAccountByName(string name)
        {
            var account = _Find(name);

            if (account != null)
                return account;

            return new Regulus.Remoting.Value<Data.Account>(null);
        }

        private Data.Account _Find(string name)
        {
            var task = _Database.Find<Data.Account>(a => a.Name == name);
            task.Wait();
            return task.Result.FirstOrDefault();
        }
        private Data.Account _Find(Guid id)
        {
            var task = _Database.Find<Data.Account>(a =>a.Id == id);
            task.Wait();
            return task.Result.FirstOrDefault();
        }

        Regulus.Remoting.Value<ACCOUNT_REQUEST_RESULT> VGame.Project.FishHunter.IAccountManager.Create(Data.Account account)
        {
            var result = _Find(account.Name);
            if(result != null)
            {
                return ACCOUNT_REQUEST_RESULT.REPEAT;
            }
            _Database.Add(account);
            return ACCOUNT_REQUEST_RESULT.OK;
        }

        Regulus.Remoting.Value<ACCOUNT_REQUEST_RESULT> VGame.Project.FishHunter.IAccountManager.Delete(string account)
        {
            var result = _Find(account);
            if (result != null && _Database.Remove<Data.Account>(a => a.Id == result.Id))
            {                
                return ACCOUNT_REQUEST_RESULT.OK;
            }

            return ACCOUNT_REQUEST_RESULT.NOTFOUND;
        }

        Regulus.Remoting.Value<Data.Account[]> _QueryAllAccount()
        {
            var val = new Regulus.Remoting.Value<Data.Account[]>();
            var t = _Database.Find<Data.Account>(a => true);
            t.ContinueWith(list => { val.SetValue(list.Result.ToArray()); });
            return val;            
        }
        Regulus.Remoting.Value<Data.Account[]> IAccountManager.QueryAllAccount()
        {
            return _QueryAllAccount();
        }


        Regulus.Remoting.Value<ACCOUNT_REQUEST_RESULT> IAccountManager.Update(Data.Account account)
        {
            if (_Database.Update(account, a => a.Id == account.Id))            
                return ACCOUNT_REQUEST_RESULT.OK;
            return ACCOUNT_REQUEST_RESULT.NOTFOUND;
        }


        Regulus.Remoting.Value<Data.Account> IAccountFinder.FindAccountById(Guid accountId)
        {
            return _Find(accountId);
        }
    }
}
