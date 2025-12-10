// Autocompletar municipios
        $(function() {
   
            var data_1 = [
                "ActionScript",
                "AppleScript",
                "Asp",
                "BASIC",
                "C",
                "C++",
                "Clojure",
                "COBOL",
                "ColdFusion",
                "Erlang",
                "Fortran",
                "Groovy",
                "Haskell",
                "Java",
                "JavaScript",
                "Lisp",
                "Perl",
                "PHP",
                "Python",
                "Ruby",
                "Scala",
                "Scheme"
            ];
    
            $("#quick-search").autocomplete({
                source: data_1,
                open: function(event, ui) {
                    
                    var autocomplete = $(".ui-autocomplete:visible");
                    var oldTop = autocomplete.offset().top;
                    var newTop = oldTop - $("#quick-search").height() + 25;
                    autocomplete.css("top", newTop);
                    
                }
            });
            
        }); 