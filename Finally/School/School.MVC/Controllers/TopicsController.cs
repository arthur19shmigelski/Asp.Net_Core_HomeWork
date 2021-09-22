using AutoMapper;
using ElmahCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using School.BLL.Models;
using School.BLL.Services.Topic;
using School.BLL.ShortModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.MVC.Controllers
{
    public class TopicsController : Controller
    {
        private readonly ITopicService _topicService;

        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public TopicsController(IMapper mapper,
                                ITopicService topicService,
                                ILogger<TopicsController> logger)
        {
            _mapper = mapper;
            _logger = logger;

            _topicService = topicService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var topics = await _topicService.GetAll();

                return View(_mapper.Map<IEnumerable<TopicModel>>(topics));
            }
            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                var topicModel = id.HasValue ?
                    _mapper.Map<TopicModel>(await _topicService.GetById(id.Value)) :
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
        public async Task<IActionResult> Edit(TopicModel topicModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var topic = _mapper.Map<Topic>(topicModel);
                    if (topic.Id == 0)
                        await _topicService.Create(topic);
                    else
                        await _topicService.Update(topic);

                    return RedirectToAction(nameof(Index));
                }

                return View(topicModel);
            }
            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var topic = await _topicService.GetById(id);
                if(topic.Courses.Count>0)
                {

                }    
                await _topicService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }
    }
}