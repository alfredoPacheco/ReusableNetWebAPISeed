﻿using ReusableWebAPI.Auth;
using Newtonsoft.Json;
using RepositoryLogic;
using RepositoryLogic.BaseEntity;
using RepositoryLogic.BaseLogic;
using System;
using System.Reflection;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ReusableWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public abstract class BaseController<E> : ApiController where E : Entity
    {
        protected ILogic<E> _logic;

        public BaseController(ILogic<E> logic)
        {
            _logic = logic;

            LoggedUser loggedUser = new LoggedUser((ClaimsIdentity)User.Identity);
            _logic.byUserId = loggedUser.UserID;
        }

        // GET: api/Base
        [HttpGet Route("")]
        virtual public CommonResponse Get()
        {
            return _logic.GetAll();
        }

        // GET: api/Base/5
        [HttpGet Route("")]
        virtual public CommonResponse Get(int id)
        {
            return _logic.GetByID(id);
        }

        // GET: api/Base
        [HttpGet Route("getCatalogs")]
        virtual public CommonResponse getCatalogs()
        {
            return _logic.GetCatalogs();
        }

        // POST: api/Base
        [HttpPost Route("")]
        virtual public CommonResponse Post([FromBody]string value)
        {
            CommonResponse response = new CommonResponse();
            E entity;

            try
            {
                entity = JsonConvert.DeserializeObject<E>(value);

                return _logic.Add(entity);
            }
            catch (Exception e)
            {
                return response.Error("ERROR: " + e.ToString());
            }
        }

        // POST: api/Base
        [HttpPost Route("AddToParent/{type}/{parentId}")]
        virtual public CommonResponse AddToParent(string type, int parentId, [FromBody]string value)
        {
            CommonResponse response = new CommonResponse();

            E entity;
            try
            {
                Type parentType = Type.GetType("CMDLogic.EF." + type + ", CMDLogic", true);
                entity = JsonConvert.DeserializeObject<E>(value);

                MethodInfo method = _logic.GetType().GetMethod("AddToParent");
                MethodInfo generic = method.MakeGenericMethod(parentType);
                response = (CommonResponse)generic.Invoke(_logic, new object[] { parentId, entity });
                return response;
            }
            catch (Exception e)
            {
                return response.Error("ERROR: " + e.ToString());
            }
        }

        [HttpPost Route("Create")]
        virtual public CommonResponse Create()
        {
            return _logic.CreateInstance();
        }

        // PUT: api/Base/5
        virtual public CommonResponse Put(int id, [FromBody]string value)
        {
            CommonResponse response = new CommonResponse();
            E entity;

            try
            {
                entity = JsonConvert.DeserializeObject<E>(value);

                return _logic.Update(entity);
            }
            catch (Exception e)
            {
                return response.Error("ERROR: " + e.ToString());
            }
        }

        // DELETE: api/Base/5
        virtual public CommonResponse Delete(int id)
        {
            return _logic.Remove(id);
        }

        [HttpGet Route("GetAvailableForEntity/{sEntityType}/{id}")]
        virtual public CommonResponse GetAvailableForEntity(string sEntityType, int id)
        {
            CommonResponse response = new CommonResponse();

            try
            {
                Type forEntityType = Type.GetType("CMDLogic.EF." + sEntityType + ", CMDLogic", true);

                MethodInfo method = _logic.GetType().GetMethod("GetAvailableFor");
                MethodInfo generic = method.MakeGenericMethod(forEntityType);
                response = (CommonResponse)generic.Invoke(_logic, new object[] { id });
                return response;
            }
            catch (Exception e)
            {
                return response.Error("ERROR: " + e.ToString());
            }
        }

        [HttpPost Route("RemoveFromParent/{type}/{parentId}")]
        virtual public CommonResponse RemoveFromParent(string type, int parentId, [FromBody]string value)
        {
            CommonResponse response = new CommonResponse();

            E entity;
            try
            {
                Type parentType = Type.GetType("CMDLogic.EF." + type + ", CMDLogic", true);
                entity = JsonConvert.DeserializeObject<E>(value);

                MethodInfo method = _logic.GetType().GetMethod("RemoveFromParent");
                MethodInfo generic = method.MakeGenericMethod(parentType);
                response = (CommonResponse)generic.Invoke(_logic, new object[] { parentId, entity });
                return response;
            }
            catch (Exception e)
            {
                return response.Error("ERROR: " + e.Message, e);
            }
        }
    }
}