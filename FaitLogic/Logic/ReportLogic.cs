using AutoMapper;
using Fait.DAL.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace FaitLogic.Logic
{
    public class ReportLogic
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork unitOfWork;

        public ReportLogic(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public void CreateReport(int studentId)
        {

        }

        private void CreateDocument()
        {

        }
    }
}
