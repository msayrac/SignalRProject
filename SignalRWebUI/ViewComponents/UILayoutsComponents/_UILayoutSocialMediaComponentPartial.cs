﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.SocialMediaDtos;

namespace SignalRWebUI.ViewComponents.UILayoutsComponents
{
	public class _UILayoutSocialMediaComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _UILayoutSocialMediaComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{

			var client = _httpClientFactory.CreateClient();

			var responseMessage = await client.GetAsync("https://localhost:7244/api/SocialMedia");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
				return View(value);
			}
			return View();
		}
	}

}
