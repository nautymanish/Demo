
using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Demo.Controllers
{
    [RoutePrefix("api/question")]
    public class QuestionController : ApiController
    {
        private AuthRepository _repo = new AuthRepository();
        [Authorize]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok();//Question.GetQuestions()
        }

        [Authorize]
        [Route("submitquestion")]
        public async Task<IHttpActionResult> SubmitQuestion(Question questionModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var ctx = new Context();
                ctx.Questions.Add(questionModel);
                ctx.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest("Issue in saving");
            }
        }

        [Authorize]
        [Route("submitanswer")]
        public async Task<IHttpActionResult> SubmitAnswer(Answer answerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var ctx = new Context();
                ctx.Answers.Add(answerModel);
                ctx.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest("Issue in saving");
            }
        }

        [Authorize]
        [Route("listquestion")]
        [HttpGet]
        public IEnumerable<Question> GetListOfQuestion()
        {
            var ctx = new Context();
            List<Question> list = new List<Question>(); 
            ctx.Questions.ToList().ForEach(item=> list.Add(new Question(){ Text= item.Text, Id=item.Id}));
            return list;
        
        }
    }
    
}
