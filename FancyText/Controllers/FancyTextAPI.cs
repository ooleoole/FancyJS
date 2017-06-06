using System;
using System.Collections.Generic;
using System.Linq;
using FancyText.Repo;
using Microsoft.AspNetCore.Mvc;


namespace FancyText.Controllers
{
    [Route("api/fancyText")]
    public class FancyTextApi : Controller
    {
        private readonly IRepo<FancyTextComposition> _fancyTextCompRepo;
        private IRepo<FancyText> _fancyTextRepo;

        public FancyTextApi(IRepo<FancyTextComposition> fancyTextCompRepo,IRepo<FancyText> fancyTextRepo)
        {
            _fancyTextCompRepo = fancyTextCompRepo;
            _fancyTextRepo = fancyTextRepo;

        }
        [HttpGet,Route("GetAll")]
        public IActionResult GetAll()
        {
            var comps = _fancyTextCompRepo.GetAll().ToList();

            return Json(comps);
        }
        [HttpPost,Route("Add")]
        public IActionResult Add(FancyTextCompDto fancyText)
        {
            var fancyTextComp = FancyTextDtoToFancyTextComp(fancyText);
            try
            {
                _fancyTextCompRepo.Add(fancyTextComp);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Json(fancyTextComp);
        }

        public IActionResult Find()
        {
            return null;
        }

        public IActionResult Delete(int id)
        {
            return Ok();
        }
        [HttpPatch,Route("Update")]
        public IActionResult Update(FancyTextDto fancyTextDto)
        {
            try
            {
                var fancyText = _fancyTextRepo.GetById(fancyTextDto.Id);
                fancyText.Color = fancyTextDto.Color;
                fancyText.Text = fancyTextDto.Text;
                _fancyTextRepo.Update(fancyText);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            

            return Ok(fancyTextDto);
        }
        private static FancyTextComposition FancyTextDtoToFancyTextComp(FancyTextCompDto fancyText)
        {
            return new FancyTextComposition()
            {
                Name = fancyText.Name,
                FancyTexts = new List<FancyText>()
                {
                    new FancyText
                    {
                        Text = fancyText.Text1,
                        Color = fancyText.Color1,
                    },
                    new FancyText
                    {
                        Text = fancyText.Text2,
                        Color = fancyText.Color2
                    },
                    new FancyText
                    {
                        Text = fancyText.Text3,
                        Color = fancyText.Color3
                    }
                }
            };


        }

    }
}
