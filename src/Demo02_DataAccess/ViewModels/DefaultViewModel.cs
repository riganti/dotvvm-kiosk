using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;
using OrderManagementApp.Model;
using OrderManagementApp.Services;

namespace OrderManagementApp.ViewModels
{
	public class DefaultViewModel : SiteViewModel
	{
	    private readonly OrderService orderService;
        
        public GridViewDataSet<OrderListDTO> Orders { get; set; } = new()
        {
            PagingOptions =
            {
                PageSize = 10
            },
            SortingOptions =
            {
                SortExpression = nameof(OrderListDTO.CreatedDate),
                SortDescending = true
            }
        };

        public DefaultViewModel(OrderService orderService)
	    {
	        this.orderService = orderService;
	    }

        public override Task PreRender()
	    {
            if (Orders.IsRefreshRequired)
            {
                IQueryable<OrderListDTO> orders = orderService.GetOrdersQuery();
                Orders.LoadFromQueryable(orders);
            }

            return base.PreRender();
	    }
	}
}

