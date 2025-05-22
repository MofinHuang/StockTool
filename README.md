Target:
1. Auto get the current stock to save in database.
2. Calculate the cost and net.
3. Forecast the cost and net.

Comment:
1. Database: mysql
2. Create the table
CREATE TABLE `sys_mst_stock` (
  `KID` int NOT NULL AUTO_INCREMENT COMMENT '系統識別碼',
  `STOCK_ID` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '股票代號',
  `STOCK_NAME` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '股票名稱',
  `STOCK_KEYWORD` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '股票關鍵字',
  `DESCRIPTION` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '描述',
  `ENABLE` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '是否啟用',
  `UDT` datetime DEFAULT NULL COMMENT '異動日期時間',
  `BUY_VOLUME` double DEFAULT NULL COMMENT '買入量',
  `BUY_PRICE` double DEFAULT NULL COMMENT '買入價',
  `BUY_COST` double DEFAULT NULL COMMENT '買入成本',
  `BUY_DATE` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '買入日期',
  `SALE_PRICE` double DEFAULT NULL COMMENT '賣出價',
  `SALE_COST` double DEFAULT NULL COMMENT '賣出成本',
  `SALE_DATE` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '賣出日期',
  `FEES` double DEFAULT NULL COMMENT '手續費',
  `TAX` double DEFAULT NULL COMMENT '交易稅',
  `NET` double DEFAULT NULL COMMENT '淨賺',
  `ROI` double DEFAULT NULL COMMENT '投報率',
  `DAYS` double DEFAULT NULL COMMENT '天數',
  `ROI_YEAR` double DEFAULT NULL COMMENT '年投報率',
  `FORECAST_RATIO` double DEFAULT NULL COMMENT '預測率',
  `FORECAST_SALE_PRICE` double DEFAULT NULL COMMENT '預測賣出價',
  `FORECAST_SALE_COST` double DEFAULT NULL COMMENT '預測賣出成本',
  `FORECAST_NET` double DEFAULT NULL COMMENT '預測淨賺',
  PRIMARY KEY (`KID`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='股票基本檔';
CREATE TABLE `sys_mst_stock_info` (
  `KID` int NOT NULL AUTO_INCREMENT COMMENT '系統識別碼',
  `STOCK_ID` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '股票代號',
  `STOCK_NAME` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '股票名稱',
  `STOCK_DATE` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '股票日期',
  `STOCK_PRICE_1` double DEFAULT NULL COMMENT '昨收(A)',
  `STOCK_PRICE_2` double DEFAULT NULL COMMENT '今開(B)',
  `STOCK_PRICE_3` double DEFAULT NULL COMMENT '最高(C)',
  `STOCK_PRICE_4` double DEFAULT NULL COMMENT '最低(D)',
  `STOCK_PRICE_5` double DEFAULT NULL COMMENT '今收(E)',
  `STOCK_RATIO_1` double DEFAULT NULL COMMENT '今開%=((B)-(A))/(A)',
  `STOCK_RATIO_2` double DEFAULT NULL COMMENT '最高%=((C)-(B))/(B)',
  `STOCK_RATIO_3` double DEFAULT NULL COMMENT '最低%=((D)-(B))/(B)',
  `STOCK_RATIO_4` double DEFAULT NULL COMMENT '今收%=((E)-(B))/(B)',
  `STOCK_DIFFE_1` double DEFAULT NULL COMMENT '今開差=(B)-(A)',
  `STOCK_DIFFE_2` double DEFAULT NULL COMMENT '最高差=(C)-(B)',
  `STOCK_DIFFE_3` double DEFAULT NULL COMMENT '最低差=(D)-(B)',
  `STOCK_DIFFE_4` double DEFAULT NULL COMMENT '今收差=(E)-(B)',
  `STOCK_PRICE_MAX` double DEFAULT NULL COMMENT '最大=(B)*(1+10%)',
  `STOCK_PRICE_MIN` double DEFAULT NULL COMMENT '最小=(B)*(1-10%)',
  `STOCK_VOLUME` double DEFAULT NULL COMMENT '成交量',
  `UDT` datetime DEFAULT NULL COMMENT '異動日期時間',
  PRIMARY KEY (`KID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='股票資訊檔';
CREATE TABLE `sys_mst_stock_detail` (
  `KID` int NOT NULL AUTO_INCREMENT COMMENT '系統識別碼',
  `STOCK_ID` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '股票代號',
  `STOCK_NAME` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '股票名稱',
  `STOCK_PRICE` double DEFAULT NULL COMMENT '股票價格',
  `STOCK_VOLUME` double DEFAULT NULL COMMENT '成交量',
  `UDT` datetime DEFAULT NULL COMMENT '異動日期時間',
  PRIMARY KEY (`KID`)
) ENGINE=InnoDB AUTO_INCREMENT=3639 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='股票明細檔';
