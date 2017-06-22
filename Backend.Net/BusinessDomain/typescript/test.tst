${
  Template(Settings settings)
{
           settings.OutputExtension = ".ts";
}
}

$Classes(*)[ 

    export interface $Name$TypeParameters { $Properties[
        $name: $Type;]
    ]
}