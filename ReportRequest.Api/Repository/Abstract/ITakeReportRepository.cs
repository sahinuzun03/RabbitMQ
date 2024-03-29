﻿using Microsoft.AspNetCore.Mvc;
using ReportRequest.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportRequest.Api.Repository.Abstract
{
    public interface ITakeReportRepository
    {
        void AddReport(ReportDetail reportDetail);
        Task<bool> SaveChanges();
        Task<ActionResult<ReportDetail>> GetReport(Guid id);
        ReportDetail GetReports(Guid id);
        void Update(ReportDetail reportDetail);
    }
}
