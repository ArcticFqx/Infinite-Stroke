<?php
include("common.php");
	$link=dbConnect();

	$limit = safe($_POST['limit']);
	$rn = 1;
	$query = "SELECT * FROM $dbName . `scores` ORDER BY score LIMIT $limit";

    $result = mysql_query($query);    
    $my_err = mysql_error();
    if($result === false || $my_err != '')
    {
        echo "
        <pre>
            $my_err <br />
            $query <br />
        </pre>";
        die();
    }

    $num_results = mysql_num_rows($result);

    for($i = 0; $i < $num_results; $i++)
    {
         $row = mysql_fetch_array($result);
         echo $rn . '. ' . $row['name'] . "\t - \t " . $row['time'] . "\n";
		 $rn++;
    }
?>