$(document).ready(function(){

	$('#submit').click(function(){
		var program= $('#program').val();
		//alert(program);
      var user = $('#user').val();
			$.ajax({ url: 'compilers.php',
         data: {program:program,user:user },
         type: 'post',
         success: function(output) {
         				$('.output').html("");
         				$('.output').append("<h3>Output :</h3><br/>");
         				$('.output').append(output);
                     // alert(output);
                  }
});


		});


});