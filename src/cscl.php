<?php 

class CsharpCompiler 
{
	private $program;
	private $user;
	function __construct($program,$user)
	{
		$this->program=$program;
		$this->user=$user;
	}
	function compile()
	{

		$program = base64_encode($this->program);
		$user=$this->user;
		// update your folder accordingly
		$var = shell_exec("src\\cloud.exe cs $program $user");
		if($var=="success")
		{
			$res = shell_exec("csharp\\".$user.".exe");
			return("<pre>".$res."</pre>");
		}
		else
		{
			return("<pre>".$var."</pre>");
		}

	}

}

?>