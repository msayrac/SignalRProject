﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DiscountController : ControllerBase
	{
		private readonly IDiscountService _discountService;
		private readonly IMapper _mapper;

		public DiscountController(IDiscountService discountService, IMapper mapper)
		{
			_discountService = discountService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult DiscountList()
		{
			var value = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
			return Ok(value);
		}

		[HttpPost]
		public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
		{
			_discountService.TAdd(new Discount()
			{
				Title = createDiscountDto.Title,
				Description = createDiscountDto.Description,
				Amount = createDiscountDto.Amount,
				ImageUrl = createDiscountDto.ImageUrl,
				Status=false
			});
			return Ok("İndirim Bilgisi Eklendi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteDiscount(int id)
		{
			var value = _discountService.TGetByID(id);
			_discountService.TDelete(value);
			return Ok("İndirim Bilgisi Başarılı Bir Şekilde Silindi");
		}

		[HttpPut]
		public IActionResult UpdateContact(UpdateDiscountDto updateDiscountDto)
		{
			_discountService.TUpdate(new Discount()
			{
				DiscountID= updateDiscountDto.DiscountID,
				Title = updateDiscountDto.Title,
				Description = updateDiscountDto.Description,
				Amount = updateDiscountDto.Amount,
				ImageUrl = updateDiscountDto.ImageUrl,
				Status = false
			});

			return Ok("İndirim Bilgisi Başarılı Bir Şekilde Güncellendi");
		}

		[HttpGet("{id}")]
		public IActionResult GetDiscount(int id)
		{
			var value = _discountService.TGetByID(id);
			return Ok(value);
		}

		[HttpGet("ChangeStatusToTrue/{id}")]
		public IActionResult ChangeStatusToTrue(int id)
		{
			_discountService.TChangeStatusToTrue(id);
			return Ok("Ürün İndirimi Aktif Hale Getirildi");
		}

		[HttpGet("ChangeStatusToFalse/{id}")]
		public IActionResult ChangeStatusToFalse(int id)
		{
			_discountService.TChangeStatusToFalse(id);
			return Ok("Ürün İndirimi Pasif Hale Getirildi");
		}


	}
}
