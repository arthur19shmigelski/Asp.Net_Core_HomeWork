using AutoMapper;
using ElmahCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using School.BLL.Models;
using School.BLL.Services.Topic;
using School.BLL.ShortModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.MVC.Controllers
{
    public class TopicsController : Controller
    {
        private readonly ITopicService topicService;

        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public TopicsController(IMapper mapper,
                                ITopicService topicService,
                                ILogger<TopicsController> logger)
        {
            _mapper = mapper;
            _logger = logger;

            this.topicService = topicService;
        }

        public  IActionResult Index()
        {
            try
            {
                var topics =  topicService.GetAll();

                return View(_mapper.Map<IEnumerable<TopicModel>>(topics));
            }
            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpGet]
        public  IActionResult Edit(int? id)
        {
            try
            {
                var topicModel = id.HasValue ?
                    _mapper.Map<TopicModel>(topicService.GetById(id.Value)) :
                    new TopicModel();

                return View(topicModel);
            }
            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpPost]
        public  IActionResult Edit(TopicModel topicModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var topic = _mapper.Map<Topic>(topicModel);
                    if (topic.Id == 0)
                        topicService.Create(topic);
                    else
                        topicService.Update(topic);

                    return RedirectToAction("Index", "Topics");
                }

                return View(topicModel);
            }
            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }
    }
}