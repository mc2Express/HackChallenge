${
  Template(Settings settings)
{
           settings.OutputExtension = ".ts";
}
}

module Models { $Classes(*)[ 

    export interface $Name$TypeParameters { $Properties[
        $name: $Type;]
    }]
}