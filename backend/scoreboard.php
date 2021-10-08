<?php

$dbhandle = mysqli_connect('localhost','u1495592_default','YLd0Nv0k638JzKjZ','u1495592_default');

$result = mysqli_query($dbhandle,"SELECT id, @i:=@i+1 place, name, score
FROM 

(SELECT ID, NAME, round((AVG_PTP*0.25 + AVG_ACW*0.25 + AVG_ATT*0.25 + AVG_REFUSE*0.25)*100, 0) as SCORE
FROM 
(
SELECT ER_ID as ID, FIO as NAME, DATE_OF_METRICS, 
    round(SUM(convert(replace(`PTP_FROM_RPC,%`, ',', '.'), DECIMAL(10,2))),2) AVG_PTP,
    round(SUM(convert(replace(`ATT,%`, ',', '.'), DECIMAL(10,2))),2) AVG_ATT,
    round(SUM(convert(replace(`ACW,%`, ',', '.'), DECIMAL(10,2))),2) AVG_ACW,
    round(SUM(convert(replace(`REFUSE,%`, ',', '.'), DECIMAL(10,2))),2) AVG_REFUSE
FROM `Game` a
WHERE DATE_OF_METRICS = '04.09.2021'
GROUP BY ER_ID, FIO, DATE_OF_METRICS
) as `ALL`

GROUP BY ID, NAME
ORDER BY (AVG_PTP*0.25 + AVG_ACW*0.25 + AVG_ATT*0.25 + AVG_REFUSE*0.25) DESC
) as NUMB, (SELECT @i:=0) X");


if(mysqli_num_rows($result)>0){
    $rows=array();
    while($row = mysqli_fetch_assoc($result))
    {
      $rows[]=$row;
    }
    echo json_encode($rows);
}else{
    echo json_encode(array("error"=>"No records found."));
}
exit;
  
?>