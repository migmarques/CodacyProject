using CodacyProject.Common.BusinessObjects;
using CodacyProject.Facades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace CodacyProject.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CodacyProjectController
    {
        [HttpGet]
        public List<GitCommit> GetCommitListByCommandLine(string repositoryURL, int pageSize, int pageNumber)
        {
            try
            {
                return CodacyProjectFacade.GetCommitListByCommandLine(repositoryURL, pageSize, pageNumber);
            } catch(Exception e)
            {
                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(e.Message),
                    ReasonPhrase = "An error occured getting the commit list."
                };
                throw new System.Web.Http.HttpResponseException(responseMessage);
            }
            
        }
    }
}
