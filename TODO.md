# TODO: Fix StockController Issues

- [x] Update StockController.cs: Change Get() return type to ActionResult<List<StockRequest>>
- [x] Update StockController.cs: In GetById(), change mapping to _Mapper.Map<StockRequest>(Stocks)
- [x] Update StockController.cs: In CreateStock(), change mapping to _Mapper.Map<StockRequest>(CreateStock)
- [x] Update StockController.cs: In CreateStock(), change return to CreatedAtAction

# Followup: Test the API endpoints
