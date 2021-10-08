<?php

$dbhandle = mysqli_connect('localhost','u1495592_default','YLd0Nv0k638JzKjZ','u1495592_default');

  $result = mysqli_query($dbhandle,"SELECT id, name, ptp, att, acw, refuse , before1
FROM
(
SELECT a.er_id id, FIO as name,
       case when date_of_metrics in ('04.09.2021') and (PTP_FROM_RPC / PTP_FROM_RPC_PLAN) >= 1 then 1 else 0 end as ptp,
       case when date_of_metrics in ('04.09.2021') and (ATT / ATT_PLAN) >= 1 then 0 else 1 end as att,
       case when date_of_metrics in ('04.09.2021') and (ACW / ACW_PLAN) >= 1 then 0 else 1 end as acw,
       case when date_of_metrics in ('04.09.2021') and (REFUSE / REFUSE_PLAN) >= 1 then 0 else 1 end refuse,
       case when date_of_metrics in ('01.09.2021') and (PTP_FROM_RPC / PTP_FROM_RPC_PLAN) >= 1 then 1 else 0 end +
       case when date_of_metrics in ('01.09.2021') and (ATT / ATT_PLAN) >= 1 then 0 else 1 end +
       case when date_of_metrics in ('01.09.2021') and (ACW / ACW_PLAN) >= 1 then 0 else 1 end +
       case when date_of_metrics in ('01.09.2021') and (REFUSE / REFUSE_PLAN) >= 1 then 0 else 1 end +
       case when date_of_metrics in ('02.09.2021') and (PTP_FROM_RPC / PTP_FROM_RPC_PLAN) >= 1 then 1 else 0 end +
       case when date_of_metrics in ('02.09.2021') and (ATT / ATT_PLAN) >= 1 then 0 else 1 end +
       case when date_of_metrics in ('02.09.2021') and (ACW / ACW_PLAN) >= 1 then 0 else 1 end +
       case when date_of_metrics in ('02.09.2021') and (REFUSE / REFUSE_PLAN) >= 1 then 0 else 1 end +
       case when date_of_metrics in ('03.09.2021') and (PTP_FROM_RPC / PTP_FROM_RPC_PLAN) >= 1 then 1 else 0 end +
       case when date_of_metrics in ('03.09.2021') and (ATT / ATT_PLAN) >= 1 then 0 else 1 end +
       case when date_of_metrics in ('03.09.2021') and (ACW / ACW_PLAN) >= 1 then 0 else 1 end +
       case when date_of_metrics in ('03.09.2021') and (REFUSE / REFUSE_PLAN) >= 1 then 0 else 1 end before1
       
FROM Game a
WHERE a.er_id = '1000001' and date_of_metrics in ('04.09.2021')) as `ALL`");

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