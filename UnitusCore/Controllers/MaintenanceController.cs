﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using UnitusCore.Attributes;
using UnitusCore.Results;
using UnitusCore.Storage;
using UnitusCore.Storage.Base;
using UnitusCore.Storage.DataModels.Profile;
using UnitusCore.Util;

namespace UnitusCore.Controllers
{
    [RoleRestrict(GlobalConstants.AdminRoleName)]
    [ApiAuthorized]
    public class MaintenanceController : UnitusApiControllerWithTableConnection
    {
        [HttpPost]
        [Route("Maintenance/Achivements/AdjustBody")]
        public async Task<IHttpActionResult> GenerateToAdjustAchivementBody()
        {
            AchivementStatisticsStorage storage = new AchivementStatisticsStorage(TableConnection,DbSession);
            await storage.GenerateToAdjustAchivementBody();
            return Json(true);
        }
        
        [HttpPost]
        [Route("Maintenance/Achivements/AdjustCategories")]
        public async Task<IHttpActionResult> GenerateToAdjustAchivementCategories()
        {
            AchivementStatisticsStorage storage = new AchivementStatisticsStorage(TableConnection, DbSession);
            await storage.Maintenance_GenerateAchivementCategoriesForExisitingAchivementBody();
            return Json(true);
        }

        [HttpPost]
        [Route("Maintenance/Skills")]
        public async Task<IHttpActionResult> AppendNewSkill(AppendNewSkillRequest request)
        {
            return await this.OnValidToken(request, async (r) =>
            {
                await Ensure.IsNotExisitingSkillName(request.SkillName);
                SkillProfileStorage storage=new SkillProfileStorage(TableConnection);
                await storage.AppendSkill(request.SkillName);
                return Json(ResultContainer.GenerateSuccessResult());
            });
        }

        public class AppendNewSkillRequest : AjaxRequestModelBase,ISkillInfo
        {
            public string SkillName { get; set; }
        }
    }
}
