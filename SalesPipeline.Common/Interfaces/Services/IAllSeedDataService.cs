using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Common.Interfaces.Services
{
    using Models;

    public interface IAllSeedDataService
    {
        /// <summary>
        /// Sends all Seed Data to the project
        /// </summary>
        /// <param name="classifications">a list of all Sold Classifications</param>
        /// <param name="enrollmentMethods">List of all enrollment methods</param>
        /// <param name="enrollmentSystems">A list of all enrollment systems</param>
        /// <param name="salesExecs">A list of all sales execs</param>
        /// <param name="vBCarriers">A list of all vb carriers</param>
        void ExportSeedData(List<Classification> classifications, List<EnrollmentMethod> enrollmentMethods, List<EnrollmentSystem> enrollmentSystems, List<SalesExec> salesExecs, List<VBCarrier> vBCarriers);
    }
}

