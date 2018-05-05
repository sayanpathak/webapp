using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oxford.CSHttpClientSample;

namespace WepApi.Controllers
{
    [Route("api/[controller]")]
    public class RankingController : Controller
    {
        [HttpGet]
        public string GetRanking(string keywords)
        {
            if (string.IsNullOrWhiteSpace(keywords)) return "keywords cannot be empty";
            string result = OcrProgram.MakeAnalysisRequest(keywords);
            if (result == "Bad Request") throw new ApplicationException("Bad request");

            List<string> resultWords = OcrProgram.ExtractWords(result);
            string fullText = OcrProgram.DisplayWords(resultWords);
            if(string.IsNullOrWhiteSpace(fullText)) throw new ApplicationException("No text on image was recognized");
            return fullText;
        }
    }
}
