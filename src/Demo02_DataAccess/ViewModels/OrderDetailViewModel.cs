using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using OrderManagementApp.Model;
using OrderManagementApp.Services;

namespace OrderManagementApp.ViewModels
{
	public class OrderDetailViewModel : SiteViewModel
	{
	    private readonly OrderService orderService;
	    private readonly ProductService productService;

	    public OrderDetailViewModel(OrderService orderService, ProductService productService)
	    {
	        this.orderService = orderService;
	        this.productService = productService;
	    }

        [FromRoute("Id")]
	    public int EditedOrderId { get; set; }

	    public bool IsNew => EditedOrderId == 0;

	    public OrderDetailDTO EditedOrder { get; set; }

        [Bind(Direction.ServerToClientFirstRequest)]
	    public List<ProductListDTO> Products => productService.GetProducts();


	    public override Task PreRender()
	    {
	        if (!Context.IsPostBack)
	        {
	            if (!IsNew)
	            {
	                EditedOrder = orderService.GetOrderDetail(EditedOrderId);
	            }
	            else
	            {
	                EditedOrder = new OrderDetailDTO()
	                {
	                    OrderItems = new List<OrderItemDetailDTO>()
	                };
	            }
	        }

	        return base.PreRender();
	    }

	    public void AddOrderItem()
	    {
	        EditedOrder.OrderItems.Add(new OrderItemDetailDTO()
	        {
	            Quantity = 1,
                ProductId = Products.First().Id
	        });
	        RecalculatePrice();
	    }

        public void RemoveOrderItem(OrderItemDetailDTO item)
        {
	        EditedOrder.OrderItems.Remove(item);
	        RecalculatePrice();
        }

	    public void RecalculatePrice()
	    {
	        orderService.RecalculateOrderTotalPrice(EditedOrder);
        }

        public void SaveChanges()
	    {
	        orderService.SaveOrderDetail(EditedOrder);
            Context.RedirectToRoute("Default");
	    }
	}
}

