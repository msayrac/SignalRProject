using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;
using System.Net.Mail;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingController : ControllerBase
	{
		private readonly IBookingService _bookingService;

		public BookingController(IBookingService bookingService)
		{
			_bookingService = bookingService;
		}

		[HttpGet]
		public IActionResult BookingList()
		{
			var values = _bookingService.TGetListAll();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateBooking(CreateBookingDto createBookingDto)
		{
			Booking booking = new Booking()
			{
				Name = createBookingDto.Name,
				Phone = createBookingDto.Phone,
				Mail = createBookingDto.Mail,
				PersonCount = createBookingDto.PersonCount,
				Date = createBookingDto.Date
			};
			_bookingService.TAdd(booking);
			return Ok("Booking Başarılı Yapıldı");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteBooking(int id)
		{
			var value = _bookingService.TGetByID(id);

			_bookingService.TDelete(value);
			return Ok("Booking Başarılı Bir Şekilde İptal Edildi");
		}

		[HttpPut]
		public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
		{
			Booking booking = new Booking()
			{
				Mail = updateBookingDto.Mail,
				BookingID = updateBookingDto.BookingID,
				Name = updateBookingDto.Name,
				PersonCount = updateBookingDto.PersonCount,
				Phone = updateBookingDto.Phone,
				Date = updateBookingDto.Date
			};

			_bookingService.TUpdate(booking);
			return Ok("Booking Başarılı Şekilde Güncellendi");
		}

		[HttpGet("{id}")]
		public IActionResult GetBooking(int id)
		{
			var value = _bookingService.TGetByID(id);
			return Ok(value);
		}







	}
}
