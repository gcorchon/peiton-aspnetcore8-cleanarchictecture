SELECT 
	Caja.*,
    SUM(case when Anticipo=1 then 0 else Importe end) OVER (ORDER BY FechaPago, Pk_Caja ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW)
     + Tutelado.SaldoInicialCaja AS Balance    
FROM 
    Caja inner join Tutelado on Caja.Fk_Tutelado = Pk_Tutelado
ORDER BY 
   FechaPago desc, Pk_Caja desc