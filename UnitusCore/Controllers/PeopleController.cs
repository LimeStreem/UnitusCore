﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.AspNet.Identity.Owin;
using UnitusCore.Attributes;
using UnitusCore.Controllers.Misc;
using UnitusCore.Models;
using UnitusCore.Models.DataModel;
using UnitusCore.Results;
using UnitusCore.Util;

namespace UnitusCore.Controllers
{
    public class PeopleController : UnitusApiController
    {
        [UnitusCorsEnabled]
        [Route("Person")]
        [ApiAuthorized]
        [RoleRestrict("Administrator")]
        [HttpGet]
        public async Task<IHttpActionResult> GetPersonList(string validationToken, int Count = 20, int Offset = 0)
        {
            return await this.OnValidToken(validationToken, () =>
            {
                var persons =
                    DbSession.People.OrderBy(o => o.Id)
                        .Skip(Offset)
                        .Take(Count)
                        .Select(a => a).ToArray();
                return
                    Json(
                        ResultContainer<GetPersonListResponse>.GenerateSuccessResult(
                            new GetPersonListResponse(
                                persons.Select(a => GetPersonListPersonEntity.FromPerson(a)).ToArray())));
            });
        }

        [UnitusCorsEnabled]
        [Route("Person/Dummy")]
        [HttpGet]
        public async Task<IHttpActionResult> GetPersonListDummy(int Count = 20, int Offset = 10)
        {
            return await this.OnValidToken("", () =>
            {
                var randomValues = new GetPersonListPersonEntity[178];
                for (int index = 0; index < randomValues.Length; index++)
                {
                    randomValues[index] = GetPersonListPersonEntity.GenerateDummy(index);
                }
                var persons =
                    randomValues.AsQueryable().OrderBy(o => o.Name)
                        .Skip(Offset)
                        .Take(Count)
                        .Select(a => a).ToArray();

                return
                    Json(
                        ResultContainer<GetPersonListResponse>.GenerateSuccessResult(
                            new GetPersonListResponse(persons.ToArray())));
            });
        }


        public class PutPersonRequest : AjaxRequestModelBase
        {
            public string UserName { get; set; }

            public string UserId { get; set; }


        }


        public class GetPersonListRequest : AjaxRequestModelBase
        {
            public GetPersonListRequest()
            {
                Count = 20;
                Offset = 0;
            }

            public int Count { get; set; }

            public int Offset { get; set; }
        }

        public class GetPersonListResponse
        {
            public GetPersonListResponse()
            {

            }

            public GetPersonListResponse(GetPersonListPersonEntity[] persons)
            {
                Persons = persons;
            }

            public GetPersonListPersonEntity[] Persons { get; set; }
        }

        public class GetPersonListPersonEntity:ISchoolInfoContainer
        {

            public static GetPersonListPersonEntity FromPerson(Person p)
            {
                return new GetPersonListPersonEntity(p.Email, p.BelongedSchool, p.Name, p.CurrentGrade);
            }

            public static GetPersonListPersonEntity GenerateDummy(int index)
            {
                return new GetPersonListPersonEntity(index + IdGenerator.GetId(4) + "@gmail.com",
                    IdGenerator.GetId(4) + "大学", IdGenerator.GetId(4) + " " + IdGenerator.GetId(4),
                    IdGenerator.GetRandomEnum<Person.Grade>());
            }

            public string UserName { get; set; }

            public string BelongedSchool { get; set; }

            public string Name { get; set; }

            public Person.Grade Grade { get; set; }


            public GetPersonListPersonEntity()
            {
            }

            public GetPersonListPersonEntity(string userName, string belongedSchool, string name, Person.Grade grade)
            {
                UserName = userName;
                BelongedSchool = belongedSchool;
                Name = name;
                Grade = grade;
            }
        }

    }
}
