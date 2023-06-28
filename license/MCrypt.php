<?php
  function uniord($u) 
  {
    $k = mb_convert_encoding($u, 'UCS-2LE', 'UTF-8');
    $k1 = ord(substr($k, 0, 1));
    $k2 = ord(substr($k, 1, 1));
    return $k2 * 256 + $k1;
  } 
  function unichr($codepoint)
  {
      if ($codepoint < 0x7F) return chr($codepoint); // U+0000-U+007F - 1 byte 
      if ($codepoint < 0x7FF) return chr(0xC0 | ($codepoint >> 6)).chr(0x80 | ($codepoint & 0x3F)); // U+0080-U+07FF - 2 bytes
      if ($codepoint < 0xFFFF) return chr(0xE0 | ($codepoint >> 12)).chr(0x80 | (($codepoint >> 6) & 0x3F)).chr(0x80 | ($codepoint & 0x3F)); // U+0800-U+FFFF - 3 bytes
      else // U+010000-U+10FFFF - 4 bytes
          return chr(0xF0 | ($codepoint >> 18)).chr(0x80 | ($codepoint >> 12) & 0x3F).chr(0x80 | (($codepoint >> 6) & 0x3F)).chr(0x80 | ($codepoint & 0x3F));
  }
  
  function MEncrypt($x)
  {
	  
			$list = array(0 => "A0DHY", 
						  1 => "1ZLOP", 
						  2 => "QEWX2", 
						  3 => "TF3G",
						  4 => "U4CB",
						  5 => "5IMN",
						  6 => "R6", 
						  7 => "7S", 
						  8 => "J8", 
						  9 => "K9V",
						 );
	  
            $res = "";
            for ($i = 0; $i < mb_strlen($x); $i++)
            { 
				$ch = uniord(mb_substr($x,$i,1));
                $ed = $ch % 10; $ch /= 10;
                $des = $ch % 10; $ch /= 10;
                $sot = $ch % 10; $ch /= 10;
                $tys = $ch % 10;

                $res = $res.$list[$ed][rand(0, strlen($list[$ed])-1)];
                $res = $res.$list[$des][rand(0, strlen($list[$des])-1)];
                $res = $res.$list[$sot][rand(0, strlen($list[$sot])-1)];
                $res = $res.$list[$tys][rand(0, strlen($list[$tys])-1)];
            }
            return $res;
  }
  
  function MDecrypt($x)
  {
			$database = "A0DHY1ZLOPQEWX2TF3GU4CB5IMNR67SJ8K9V";
			$listS = array(0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 9);
	  
	        $res = "";
		if (!empty($x))	
            for ($i = 0; $i < strlen($x); $i += 4)
            {
                $ed = $listS[strpos($database, $x[$i])];
                $des = $listS[strpos($database, $x[$i+1])];
                $sot = $listS[strpos($database, $x[$i+2])];
                $tys = $listS[strpos($database, $x[$i+3])];
                $ch = ($tys * 1000) + ($sot * 100) + ($des * 10) + $ed;

                $res = $res.unichr($ch);
            }
            return $res;
  }
?>