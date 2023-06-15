SELECT
T.plane as [Название]
, PIT.date as [Дата]
, P.name as [Имя пассажира]
, PIT.place as [Номер места]
FROM 
[dbo].[Pass_in_trip] AS PIT
LEFT JOIN [dbo].[Trip] T 
ON T.trip_no = PIT.trip_no
LEFT JOIN [dbo].[Passenger] AS P
ON P.ID_psg = PIT.ID_psg